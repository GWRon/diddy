
Import target

Class BmaxTarget Extends Target

	Function IsValid()
		If FileType( "bmax" )<>FILETYPE_DIR Return False
		Return True
	End

	Method Begin()
		ENV_TARGET="bmax"
		ENV_LANG="bmx"
		_trans=New BmxTranslator
	End
	
	Method Config$()
		Local config:=New StringStack
		For Local kv:=Eachin Env
			config.Push "CONST "+kv.Key+":String="+LangEnquote( kv.Value )
		Next
		Return config.Join( "~n" )
	End
	
	Method MakeTarget()
	
		'app data
		CreateDataDir "data"

'		Local meta$="var META_DATA=~q"+MetaData()+"~q;~n"
		
		'app code
		Local main$=LoadString( "MonkeyGame.bmx" )
		
		main=ReplaceBlock( main,"TRANSCODE",transCode, "~n'" )
'		main=ReplaceBlock( main,"METADATA",meta )
		main=ReplaceBlock( main,"CONFIG",Config(), "~n'" )

'		main=ReplaceBlock( main,"${TRANSCODE_BEGIN}","${TRANSCODE_END}",transCode )
		
		SaveString main,"MonkeyGame.bmx"
		
		If OPT_ACTION>=ACTION_BUILD

			Select ENV_CONFIG
				Case "release"
					Execute BMAX_PATH+" makeapp -a -r -v -t gui MonkeyGame.bmx"
				Case "debug"
					Execute BMAX_PATH+" makeapp -d MonkeyGame.bmx"
			End

			If OPT_ACTION>=ACTION_RUN
				Execute "MonkeyGame.exe",False
			Endif
		Endif
	End	
End
