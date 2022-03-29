/*  
 20/03/2022 Brayan Villa  
 ActivationRecord Class
*/


using System;
using System.IO;
using System.Diagnostics;

public class ActivationRecord
{

	public string FindAR()
	{
		
		RenciSshNetClass Renci = new RenciSshNetClass();
		
		string Resultado = Renci.SSH("rm -rf /private/var/containers/Data/System/*/Library/Caches/com.apple.LaunchServices* &>/log && grep -Rh com.apple.mobileactivationd /private/var/containers/Data/System | sed 's/Binary file //g' | sed 's/.com.apple.mobile_container_manager.metadata.plist matches//g'");
		
		string ActivationRecords = Resultado.Replace("\n", "") + "Library/activation_records";
		
		return ActivationRecords;
		
	}
	
	public string FindDA()
	{
		
		RenciSshNetClass Renci = new RenciSshNetClass();
		
		string Resultado = Renci.SSH("rm -rf /private/var/containers/Data/System/*/Library/Caches/com.apple.LaunchServices* &>/log && grep -Rh com.apple.mobileactivationd /private/var/containers/Data/System | sed 's/Binary file //g' | sed 's/.com.apple.mobile_container_manager.metadata.plist matches//g'");
		
		string ActivationRecords = Resultado.Replace("\n", "") + "Library/internal";
		
		return ActivationRecords;
		
	}    
	
	public string FindFKD()
	{
		
		RenciSshNetClass Renci = new RenciSshNetClass();
		
		string Resultado = Renci.SSH("grep -Rh com.apple.fairplayd.H2 /private/var/containers/Data/System | sed 's/Binary file //g' | sed 's/.com.apple.mobile_container_manager.metadata.plist matches//g'");
		
		string ActivationRecords = Resultado.Replace("\n", "") + "Documents/";
		
		return ActivationRecords;
		
	}    

}
