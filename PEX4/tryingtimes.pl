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

%time(List,Time) returns time of a list of activities
time([],0).
time([A],T):-
	activity(_,_,A,T).
time([Head|Tail],T):-
	time([Head],First),
	time(Tail,Later),
	T is First + Later.

% longer_path(A,B,length) returns true when there exists a path from A
% to B that has time longer than length.
longer_path(A,B,L):-
	path(A,B,Path),
	time(Path, T),
	T > L.

% critical_path(Path,Length) returns the length of the longest path from
% the first event to the last
critical_path(Path,Length):-
	start(A),
	end(B),
	path(A,B,Path),
	time(Path,Length),
	not(longer_path(A,B,Length)).















