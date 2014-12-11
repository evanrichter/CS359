%path(A,B,Path) returns possible paths traversed to get from A to B
path(A,A,[]).
path(A,B,[Path]):-
	activity(A,B,Path,_). %is there a direct link between A and B?
path(A,B,[Head|Tail]):-
	activity(A,X,Head,_), %from A, can I go somewhere with activity Head?
	X \= B,               %is that next point the final destination? If not,
	path(X,B,Tail).       %can I make a path from the intermediate point to
                              %the destination with the activities left?











