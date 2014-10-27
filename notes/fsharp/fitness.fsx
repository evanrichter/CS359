type activeDutyMember =
    | Cadet of string * string * int * int
    | Officer of string * string * string

let sumScoreString s1 s2 =
    string (s1 + s2)


let getFitnessString adm =
    match adm with
    | Cadet(fname, lname, pft, aft) when aft < 200 || pft < 200 ->
        fname + " " + lname + ": " + "Fitness score " +  sumScoreString (aft) (pft) + ". Deficient"
    | Cadet(fname, lname, pft, aft) when aft < 250 || pft < 250 -> 
        fname + " " + lname + ": " + "Fitness score " +  sumScoreString (aft) (pft) + ". On reconditioning"
    | Cadet(fname, lname, pft, aft) when aft + pft > 700 -> 
        fname + " " + lname + ": " + "Fitness score " +  sumScoreString (aft) (pft) + ". Great job!"
    | Cadet(fname, lname, pft, aft)  -> 
        fname + " " + lname + ": " + "Fitness score " +  sumScoreString (aft) (pft) 
    | Officer(fname, lname, rating) when rating = "Excellent" ->
        fname + " " + lname + ": " + "Fitness score " +  rating + ". Great job!"
    | Officer(fname, lname, rating) when rating = "Unsatisfactory" ->
        fname + " " + lname + ": " + "Fitness score " +  rating + ". Deficient"
    | Officer(fname, lname, rating) ->
        fname + " " + lname + ": " + "Fitness score " +  rating 
    | _ -> "No matching cases"
    
        
