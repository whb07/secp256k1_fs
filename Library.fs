namespace secp256k1_fs

module Say =
    open System.Runtime.InteropServices
    
    let SECP256K1_FLAGS_BIT_CONTEXT_SIGN = (uint 1 <<< 8)
    let SECP256K1_FLAGS_TYPE_CONTEXT = (uint 1 <<<  0)
    let SECP256K1_CONTEXT_SIGN =  SECP256K1_FLAGS_TYPE_CONTEXT ||| SECP256K1_FLAGS_BIT_CONTEXT_SIGN

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_scalar = {
        [<MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)>]
        d:int[]
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_pubkey = {
        [<MarshalAs(UnmanagedType.ByValArray,SizeConst = 64)>]
        data:byte[]
    }

    let new_pub():secp256k1_pubkey =
        let lst = 
             List.map ( (fun x -> x * 0) >> byte) [0..63]
            |> List.toArray
        {data=lst}
    
    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_fe_storage = {
        [<MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)>]
        n:int[]
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_ge_storage = {
        x:secp256k1_fe_storage[]
        y:secp256k1_fe_storage[]
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_ecmult_context = {
        pre_g: secp256k1_ge_storage[]
        pre_g_128: secp256k1_ge_storage[]
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_context_struct =  { 
        [<MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)>]
        n:int[]
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_fe =  { 
        [<MarshalAs(UnmanagedType.ByValArray,SizeConst = 5)>]
        n:int[]
    }
    
    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_gej = {
        x: secp256k1_fe
        y: secp256k1_fe
        z: secp256k1_fe
        infinity: int
    }

    [<StructLayout(LayoutKind.Sequential)>]
    [<Struct>]
    type secp256k1_ecmult_gen_context = {
        prec: secp256k1_ge_storage[][]
        blind: secp256k1_scalar
        initial: secp256k1_gej
    }

    let hello name =
        printfn "Hello %s" name
