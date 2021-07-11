open System
open System.Runtime.InteropServices
// open System.Runtime.CompilerServices
// open FSharp.NativeInterop

open secp256k1_fs

[<DllImport(@"C:/Users/william/RiderProjects/ScratchSpace/cmake-build-debug/lib.dll")>]
extern uint create_pubkey(IntPtr pubkey, byte[] seckey)

let checkNull n =
    n = IntPtr.Zero

[<EntryPoint>]
let main argv =
    let mutable seckey = 
        List.map byte [0..31]
        |> List.toArray
    
    let mutable pubkey = Say.new_pub()
    printfn "Pubkey is %A" pubkey
    let mutable pnt = Marshal.AllocHGlobal(Marshal.SizeOf(pubkey));

    Marshal.StructureToPtr(pubkey, pnt, false)
    let x = create_pubkey(pnt, seckey)
    let pubkey = Marshal.PtrToStructure<Say.secp256k1_pubkey>(pnt)
    // let mutable x = new_dog 10
    // double_age x



    printfn "Hello world length is %A" x
    
    printfn "Pubkey is %A" pubkey
    // free_dog x
    Marshal.FreeHGlobal(pnt)
    0 // return an integer exit code