%event(X) means X is an event
event(a).
event(b).
event(c).
event(d).
event(e).
event(f).
event(g).
event(h).
event(i).
event(j).
event(k).
event(l).
event(m).
event(n).
event(o).

% activity(A,B,Task,X) means Task is work to be done between events A
% and B, with length X
activity(a,b,findRoaster,3600).
activity(b,c,buyBeans,300).
activity(c,d,driveHome,1800).
activity(d,f,boilWater,300).
activity(d,e,measureCoffee,25).
activity(e,h,grindCoffee,200).
activity(f,g,preheatPress,60).
activity(g,h,dumpWaterFromPress,5).
activity(f,k,prewetFilterAndPreheatMug,15).
activity(h,i,placeGroundsInPress,5).
activity(i,j,add50Water,10).
activity(j,k,waitSteeping,20).
activity(k,l,add200Water,30).
activity(k,l,waitBrewing,60).
activity(k,l,dumpWaterFromMug,5).
activity(k,l,attachFilter,5).
activity(l,m,invertPress,5).
activity(m,n,pressPlunger,30).
activity(n,o,add25Water,10).


%defines the start and end event
start(a).
end(o).

%path(A,B,Path) returns possible paths traversed to get from A to B
path(A,A,[]).
path(A,B,[Path]):-
	activity(A,B,Path,_). %is there a direct link between A and B?
path(A,B,[Head|Tail]):-
	activity(A,X,Head,_), %from A, can I go somewhere with activity Head?
	X \= B,               %is that next point the final destination? If not,
	path(X,B,Tail).       %can I make a path from the intermediate point to
                              %the destination with the activities left?

