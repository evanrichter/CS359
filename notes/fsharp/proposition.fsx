
type proposition =
    | True
    | Not of proposition
    | And of proposition * proposition
    | Or of proposition * proposition

let rec eval prop =
    match prop with
    | True -> true
    | Not(prop) -> not (eval prop)
    | And(prop1, prop2) -> eval(prop1) && eval(prop2)
    | Or(prop1, prop2) -> eval(prop1) || eval(prop2)