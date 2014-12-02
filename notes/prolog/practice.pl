removeKthElement(List,0,List).
removeKthElement([_|Tail],1,Tail).
removeKthElement([Head|Tail],K,[Head|Rest]) :-
	NewK is K - 1,
	removeKthElement(Tail,NewK,Rest).


split(List,0,[],List).
split([Head|Tail],L,[Head|Tail1],Tail2) :-
	NewL is L - 1,
	split(Tail,NewL,Tail1,Tail2).

removeDups([],[]).
removeDups([Only],[Only]).
removeDups([Head|Tail],Result) :-
	Tail = [NextHead|Rest],
	Head = NextHead,
	removeDups([Head|Rest],Result).
removeDups([Head|Tail],[Head|Rest]) :-
	Tail = [NextHead|_],
	Head \= NextHead,
	removeDups(Tail,Rest).
