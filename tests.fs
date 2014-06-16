module tests

open FsUnit
open NUnit.Framework
open impl

[<SetUp>]
let setup () =
    initializeGuesses ()

[<Test>]
let ``"" witn "" should guess AAAA`` () =
    makeNextGuess "" "" |> should equal "AAAA"

[<Test>]
let ``AAAA witn "" should guess BBBB`` () =
    makeNextGuess "AAAA" "" |> should equal "BBBB"

[<Test>]
let ``BBBB witn "" should guess AAAA`` () =
    makeNextGuess "BBBB" "" |> should equal "AAAA"

[<Test>]
let ``AAAA and BBBB witn "" should guess CCCC`` () =
    makeNextGuess "AAAA" "" |> ignore
    makeNextGuess "BBBB" "" |> should equal "CCCC"

[<Test>]
let ``AAAB witn "-" should guess BBBC`` () =
    makeNextGuess "AAAB" "-" |> should equal "BBBC"

[<Test>]
let ``AAAB witn "--" should guess BBBA`` () =
    makeNextGuess "AAAB" "--" |> should equal "BBBA"

[<Test>]
let ``AABB witn "---" should guess BBAC`` () =
    makeNextGuess "AABB" "---" |> should equal "BBAC"

[<Test>]
let ``AABB witn "----" should guess BBAA`` () =
    makeNextGuess "AABB" "----" |> should equal "BBAA"

[<Test>]
let ``AAAA witn "+" should guess ABBB`` () =
    makeNextGuess "AAAA" "+" |> should equal "ABBB"

[<Test>]
let ``ABCD witn "++" should guess AAAD`` () =
    makeNextGuess "ABCD" "++" |> should equal "AAAD"

[<Test>]
let ``ABCD witn "+++" should guess AACD`` () =
    makeNextGuess "ABCD" "+++" |> should equal "AACD"

[<Test>]
let ``ABCD witn "++++" should guess ABCD`` () =
    makeNextGuess "ABCD" "++++" |> should equal "ABCD"

[<Test>]
let ``ABCD witn "-+" should guess AAAB`` () =
    makeNextGuess "ABCD" "-+" |> should equal "AAAB"

[<Test>]
let ``ABCD witn "---+" should guess ACDB`` () =
    makeNextGuess "ABCD" "---+" |> should equal "ACDB"

[<Test>]
let ``ABCD witn "--++" should guess ABDC`` () =
    makeNextGuess "ABCD" "--++" |> should equal "ABDC"
