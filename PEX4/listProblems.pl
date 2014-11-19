removeKthElement([],_,[]).
removeKthElement([_|Tail],1,Tail).
removeKthElement([Head|Tail],K,[Head|Result]):-
	Kminus is K - 1,
	removeKthElement(Tail,Kminus,Result).


split([],_,[],[]).
split([Head|Tail],1,[Head],Tail).
split([Head|Tail],K,L1,L2):-
	Kminus is K-1,
	L1 = [Head|NextHead],
	split(Tail,Kminus,NextHead,L2).


removeDups([],[]).
removeDups([Only],[Only]).
removeDups([Head|Tail],[Head|NewList]):-
	Tail = [NextHead|NewTail],
	Head \= NextHead,
	removeDups([NextHead|NewTail],NewList).
removeDups([Head|Tail],NewList):-
	Tail = [NextHead|NewTail],
	Head = NextHead,
	removeDups([Head|NewTail],NewList).

