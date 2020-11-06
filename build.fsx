// include Fake modules, see Fake modules section

open Fake.Core

// *** Define Targets ***
Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning the app --- "
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building the app --- "
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Deploy"

// *** Start Build ***
Target.runOrDefault "Deploy"