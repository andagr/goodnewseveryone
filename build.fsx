// include Fake modules, see Fake modules section

open Fake.Core
open Fake.DotNet

// *** Define Targets ***
Target.create "Clean" (fun _ ->
  let setOptions (options: DotNet.Options) = options
  let processResult = DotNet.exec setOptions "clean" "src/goodnewseveryone.fsproj"
  if processResult.ExitCode <> 0 then
    raise (MSBuildException("Clean failed with", processResult.Errors))
)

Target.create "Build" (fun _ ->
  let setBuildOptions (buildOptions: DotNet.BuildOptions) = buildOptions
  DotNet.build setBuildOptions "src/goodnewseveryone.fsproj"
)

// Target.create "Deploy" (fun _ ->
//   Trace.log " --- Deploying app --- "
// )

open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  // ==> "Deploy"

// *** Start Build ***
Target.runOrDefault "Build"