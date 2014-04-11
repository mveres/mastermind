module tests

open FsUnit
open NUnit.Framework
open impl

[<Test>]
let ``AAAA,++++ -> no new guess`` () =
    makeGuess 
        ["AAAA","++++"]
    |> should equal ""

[<Test>]
let ``AAAA,+++ -> new guess is AAAB`` () =
    makeGuess 
        ["AAAA","+++"]
    |> should equal "AAAB"

[<Test>]
let ``["AAAA","+++";"AAAB","+++"] -> new guess is AAAC`` () =
    makeGuess 
        ["AAAA","+++";
         "AAAB","+++"]
    |> should equal "AAAC"

[<Test>]
let ``["AAAA","+++"..."AAAF","+++"] -> no new guess`` () =
    makeGuess 
        ["AAAA","+++";
         "AAAB","+++";
         "AAAC","+++";
         "AAAD","+++";
         "AAAE","+++";
         "AAAF","+++";]
    |> should equal ""