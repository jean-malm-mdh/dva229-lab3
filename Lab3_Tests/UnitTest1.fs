module Lab3_Tests
    let nouns : string list = ["kaka"; "maka";"hund"; "boll"; "skräp"]
    let verbs : string list = ["söker";"hittar"; "kollar"; "babblar"]
    let rand = System.Random()
    let list_choose (l: 'a list) = 
        l[rand.Next(List.length l)]
    let grammar = Map.ofList [
                    ("<sentence>", 
                        ["<valid_question>"; "<valid_claim>"]); 
                    ("<valid_claim>", 
                        ["<noun><spacing><verb><spacing><noun><punct>"]); 
                    ("<valid_question>", 
                        ["<verb><spacing><noun><spacing><noun><punct>"]);
                    ("<noun>", 
                        nouns); 
                    ("<verb>", 
                        verbs); 
                    ("<punct>", 
                        ["";"!";".";"?"])
                    ("<spacing>", [" "; "\t"; "<spacing><spacing>"])]
    let flip_casing_by_chance chance (s: string) = 
        ///
        let mutate c = 
            if rand.NextDouble() > chance then c 
            else if System.Char.IsLower(c) then System.Char.ToUpper(c) else System.Char.ToLower(c)
        [for c in s -> c] 
        |> List.map (fun c ->  let c_res = if System.Char.IsLetter(c) then mutate c else c in c_res.ToString()) 
        |> String.concat ""
    let mutators = [flip_casing_by_chance 0.10]
    let Fuzz_Generator runs (grammar: Map<string, string list>) startRule mutators =
        let tag_matcher = System.Text.RegularExpressions.Regex("(<.*?>)")
        let has_unexpanded_section (s:string) = tag_matcher.IsMatch(s)

        let expand s =
            let tags = tag_matcher.Match(s)
            let capture = tags.Groups[0].Captures[0]
            
            // Old string bit
            s[0..capture.Index-1] + 
            // Expanded bit
            list_choose (grammar.Item capture.Value) + 
            // rest of string
            s[capture.Index+capture.Length..]

        let rec inner s =
            let unexpanded_sections = has_unexpanded_section s
            if unexpanded_sections then (inner (expand s)) else s
        let apply_mutators mutator_list string_list  = 
            if List.isEmpty mutator_list then string_list
            else 
            let rec inner sL mL acc = 
                match mL with
                | [] -> acc
                | m::ml -> inner sL ml ((List.map m sL) @ acc)
                in inner string_list mutator_list []
        [for i in 0..runs -> inner startRule] |> (apply_mutators mutators) 
    
    // [<Test>]
    // let test1 () =
    //     printfn "%A" (Fuzz_Generator 10 "<sentence>") 

    // [<Test>]
    // let ``Given Empty Sentence Then Interpreter Shall Give Error`` () =
    //     Assert.Fail("Not implemented yet")

    // [<Test>]
    // let ``Given Too Short Sentence Then Interpreter Shall Give Error`` () =
    //     Assert.Fail("Not implemented yet")

    // [<Test>]
    // let ``Given Too Long Sentence Then Interpreter Shall Give Error`` () =
    //     Assert.Fail("Not implemented yet")

    // [<Test>]
    // let ``Given a Noun Then Identifier Shall Classify it as Noun`` () =
    //     Assert.Fail("Not implemented yet")

    // [<Test>]
    // let ``Given a Verb Then Identifier Shall Classify it as Verb`` () =
    //     Assert.Fail("Not implemented yet")
        
    //TODO: Continue adding tests