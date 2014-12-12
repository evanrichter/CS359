event( a ).
event( b ).
event( c ).
event( d ).
event( e ).

start( a ).
end( e ).

activity( a, b, foundation, 5 ).
activity( b, c, walls, 6 ).
activity( b, d, plumbing, 4 ).
activity( c, d, ceiling, 5 ).
activity( c, d, electric, 2 ).
activity( d, e, painting, 2 ).

%path(A,B,Path) returns possible paths traversed to get from A to B
path(A,A,[]).
path(A,B,[Path]):-
	activity(A,B,Path,_).
path(A,B,[Head|Tail]):-
	activity(A,X,Head,_),
	X \= B,
	path(X,B,Tail).


time([], 0).
time([Start|Tail], Result) :-
	activity(_, _, Start, Time),
	time(Tail, NewTime),
	Result is Time + NewTime.
