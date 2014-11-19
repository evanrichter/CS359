% Prolog list problem 1
dupli([], []).
dupli([Item], [Item, Item]).
dupli([Head|Tail], [Head, Head | NewTail]) :-
	dupli(Tail, NewTail).

% Prolog list problem 2
getLast([Only], Only).
getLast([_|Tail], Result) :-
	getLast(Tail, Result).

% Prolog list problem 3
numElements([], 0).
numElements([_], 1).
numElements([_|Tail], Result) :-
	numElements(Tail, NumberInTail),
	Result is NumberInTail + 1.


% Prolog list problem 4
numOccurrences([], _, 0).
numOccurrences([Head|Tail], Instance, Result) :-
	Head = Instance,
	numOccurrences(Tail, Instance, OccurencesInTail),
	Result is OccurencesInTail + 1.

numOccurrences([Head|Tail], Instance, Result) :-
	Head \= Instance,
	numOccurrences(Tail, Instance, Result).


% Prolog list problem 5
myappend([], List2, List2).
myappend([Head1 | Tail1], List2, [Head1 | NewTail]) :-
	myappend(Tail1, List2, NewTail).

% Prolog list problem 6
myreverse([], []).
myreverse([Head|Tail], ReversedList) :-
	myreverse(Tail, ReversedFirstPart),
	myappend(ReversedFirstPart, [Head] , ReversedList).

% Prolog list problem 7
palindrome(List) :-
	myreverse(List, List).

