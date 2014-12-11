let rec duplicate li =
    match li with
    |[] -> []
    |[only] -> List.append [only] [only]
    |_ -> List.append (duplicate [List.head li]) (duplicate (List.tail li))


let rec merge li1 li2 =
    match li2 with
    |[] -> li1
    |[h::t] -> if h < (List.head li1) then List.append [h] (merge li1 [t])
               else List.append (List.head li1) (merge (List.tail li1) li2)



type tree =
    |Node of tree * tree
    |Leaf of int


let givenTree = Node(Leaf(1), Node(Node(Leaf(2),Leaf(3)), Leaf(4)))

let rec reverseLeaves tree =
    match tree with
    |Leaf(a) -> [a]
    |Node(x,y) -> List.append (reverseLeaves y) (reverseLeaves x)