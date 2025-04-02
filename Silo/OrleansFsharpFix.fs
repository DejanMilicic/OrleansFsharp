///assembly attributes needed for Orleans to work in F#
module OrleansFsharpFix
    
    [<assembly: Orleans.ApplicationPartAttribute("CodeGen")>]

    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Core.Abstractions")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Serialization")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Core")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Persistence.Memory")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Runtime")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Reminders")>]
    [<assembly: Orleans.ApplicationPartAttribute("OrleansDashboard.Core")>]
    [<assembly: Orleans.ApplicationPartAttribute("OrleansDashboard")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Clustering.Redis")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Persistence.Redis")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Streaming")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Serialization.Abstractions")>]
    [<assembly: Orleans.ApplicationPartAttribute("Orleans.Serialization")>]
    ()   