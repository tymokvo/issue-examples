// https://fsharp.slack.com/archives/C1R50TKEU/p1654496427111979

type Dep<'a> =
    abstract member Get: 'a

type Deps<'a, 'b>(a: Dep<'a>, b: Dep<'b>) =
    member z.A = a
    member z.B = b

let a =
    { new Dep<int> with
        member z.Get = 1 }

let b =
    { new Dep<char> with
        member z.Get = 'b' }

let deps = Deps(a, b)
