type sprinklerStartCondition =
    | Off
    | EveryNthDay of int
    | DayOfWeek of string







let turnOn condition daysSince dayToday = 
    match condition with
    | Off -> false             //This is not required, since the underscore condition
                               //below will handle Off.  It's included for clarity
    | EveryNthDay(N) when N = daysSince -> true
    | DayOfWeek(day) when day=dayToday -> true
    | _ -> false
