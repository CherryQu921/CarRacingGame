using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class Egal: MonoBehaviour {
	
	
	// Structs //
	//==================================//
	[StructLayout (LayoutKind.Sequential)]
	public struct ccn_charbuf 
	{
		public IntPtr length;
    	public IntPtr limit;
    	public IntPtr buf;
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct bufnode 
	{
		public string name;
    	public string content;
    	public IntPtr next;
	}
	
	
	// Aggregated Functions//
	//==================================//	
	[DllImport ("Egal")]
	public static extern int WriteSlice(IntPtr h, System.String prefix, System.String topo);
	// returns 0 for success
	
	[DllImport ("Egal")]
	public static extern IntPtr ReadFromRepo(System.String name);
			
	[DllImport ("Egal")]
	public static extern void WriteToRepo( System.String name, System.String content);
	
	[DllImport ("Egal")]
	public static extern IntPtr ReadFromBuffer();
	[DllImport ("Egal")]
	public static extern void PutToBuffer(string name, string content);
	[DllImport ("Egal")]
	public static extern void testbuffer(int time);
	
	// from C#, mode = 'r', name = content = null
	[DllImport ("Egal")]
	public static extern IntPtr Buffer(char mode, string name, string content);
	
	[DllImport ("Egal")]
	public static extern IntPtr GetHandle();
	
	[DllImport ("Egal")]
	public static extern int WatchOverRepo(IntPtr h, string p, string t);
	
	[DllImport ("Egal")]
	public static extern void RegisterInterestFilter(IntPtr ccn, string name);
	
	[DllImport ("Egal")]
	public static extern void AskForState(IntPtr ccn, string name, int timeout);
	
	[DllImport ("Egal")]
	public static extern int WriteToStateBuffer(string state, int statelens);
	
	
	// CCN-level Functions//
	//==================================//
	
	// ccnd, handle
	[DllImport ("Egal")]
	public static extern IntPtr ccn_create();
	
	[DllImport ("Egal")]
	public static extern int ccn_connect(IntPtr h, string name);

	[DllImport ("Egal")]
	public static extern int ccn_run(IntPtr h, int timeout);
	
	[DllImport ("Egal")]
	public static extern int ccn_set_run_timeout(IntPtr h, int timeout);
	
	// charbuf, name
	[DllImport ("Egal")]
	public static extern IntPtr ccn_charbuf_create();
	
	[DllImport ("Egal")]
	public static extern void ccn_charbuf_destroy(ref IntPtr cbp);
	
	[DllImport ("Egal")]
	public static extern IntPtr ccn_charbuf_as_string(IntPtr c);
	
	[DllImport ("Egal")]
	public static extern int ccn_name_init(IntPtr c);
	
	[DllImport ("Egal")]
	public static extern int ccn_name_from_uri(IntPtr c, string uri);
	
	[DllImport ("Egal")]
	public static extern int ccn_uri_append(IntPtr c, IntPtr ccnb, IntPtr size, int includescheme);
	
	// slice, ccns
	[DllImport ("Egal")]
	public static extern IntPtr ccns_slice_create();
	
	[DllImport ("Egal")]
	public static extern int ccns_slice_set_topo_prefix(IntPtr s, IntPtr t, IntPtr p);
	
	[DllImport ("Egal")]
	public static extern int ccns_write_slice(IntPtr h, IntPtr slice, IntPtr name);
	
	[DllImport ("Egal")]
	public static extern void ccns_slice_destroy(ref IntPtr sp);
	
	[DllImport ("Egal")]
	public static extern IntPtr ccns_open(IntPtr h, IntPtr slice,
          ccns_callback callback, IntPtr rhash, IntPtr pname);
	
	
	// Delegates, for Callback //
	//==================================//
	public delegate int ccns_callback (IntPtr ccns, IntPtr lhash, IntPtr rhash, IntPtr pname);
	
	
	// Tests //
	[DllImport ("Egal")]
	public static extern int nine();
	
}
