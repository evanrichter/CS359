%duplicate elements in a list
dupli([], []).

dupli([One], Result) :-
	Result = [One, One].

dupli([Head|Tail], [Head,Head|Result]) :-
	dupli(Tail,Result).


%find last element in a list
findLast([],0).
findLast([One],One).
findLast([_|Tail], K) :-
	findLast(Tail, K).

%find number of elements in a list
numElements([], 0).
numElements([_], 1).
numElements([_|Tail], Result) :-
	numElements(Tail,NumberInTail),
	Result is 1 + NumberInTail.
