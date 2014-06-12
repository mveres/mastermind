module tests

open FsUnit
open NUnit.Framework
open impl

[<SetUp>]
let setup () =
    initializeGuesses ()

[<Test>]
let ``"" witn "" should guess AAAA`` () =
    getNextGuess "" "" |> should equal "AAAA"

[<Test>]
let ``AAAA witn "" should guess BBBB`` () =
    getNextGuess "AAAA" "" |> should equal "BBBB"

[<Test>]
let ``BBBB witn "" should guess AAAA`` () =
    getNextGuess "BBBB" "" |> should equal "AAAA"

[<Test>]
let ``AAAA and BBBB witn "" should guess CCCC`` () =
    getNextGuess "AAAA" "" |> ignore
    getNextGuess "BBBB" "" |> should equal "CCCC"

[<Test>]
let ``AAAB witn "-" should guess BBBC`` () =
    getNextGuess "AAAB" "-" |> should equal "BBBC"

[<Test>]
let ``AAAB witn "--" should guess BBBA`` () =
    getNextGuess "AAAB" "--" |> should equal "BBBA"

[<Test>]
let ``AABB witn "---" should guess BBAC`` () =
    getNextGuess "AABB" "---" |> should equal "BBAC"

[<Test>]
let ``AABB witn "----" should guess BBAA`` () =
    getNextGuess "AABB" "----" |> should equal "BBAA"

[<Test>]
let ``AAAA witn "+" should guess ABBB`` () =
    getNextGuess "AAAA" "+" |> should equal "ABBB"

[<Test>]
let ``ABCD witn "++" should guess AAAD`` () =
    getNextGuess "ABCD" "++" |> should equal "AAAD"

[<Test>]
let ``ABCD witn "+++" should guess AACD`` () =
    getNextGuess "ABCD" "+++" |> should equal "AACD"

[<Test>]
let ``ABCD witn "++++" should guess ABCD`` () =
    getNextGuess "ABCD" "++++" |> should equal "ABCD"

[<Test>]
let ``ABCD witn "-+" should guess AAAB`` () =
    getNextGuess "ABCD" "-+" |> should equal "AAAB"

[<Test>]
let ``ABCD witn "---+" should guess ACDB`` () =
    getNextGuess "ABCD" "---+" |> should equal "ACDB"

[<Test>]
let ``ABCD witn "--++" should guess ABDC`` () =
    getNextGuess "ABCD" "--++" |> should equal "ABDC"
