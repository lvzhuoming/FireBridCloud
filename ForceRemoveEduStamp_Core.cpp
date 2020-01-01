// (C) Copyright 1990-2002 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to 
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//

//-----------------------------------------------------------------------------
//------ StdAfx.cpp : source file that includes just the standard includes
//------  StdAfx.pch will be the pre-compiled header
//------  StdAfx.obj will contain the pre-compiled type information
//-----------------------------------------------------------------------------
#include "StdAfx.h"
bool RemoveEduPlotStamp_Force(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
#ifdef _WIN64
	d1+=0x00000008;
#else
	d1+=0x00000004;
#endif
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	int i=0x00000600;
	while(true)
	{
		if(!pDb->isEMR())
		{
			return true;
		}
		i++;
		if(i>=0x00000fff)
		{
			return false;
		}
		DWORD d3=(DWORD)pVoid1;
		d3+=i;
		void* pVoid4=(void*)d3;
		DWORD* pVoid5=(DWORD*)pVoid4;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
		if((*pVoid5)==0x01)
		{
			*pVoid5=0x00;
			if(!pDb->isEMR())
		{
#if _ARXDEBUG
			acutPrintf(_T("\r\nָ��ƫ��;0x%x"),i);
#endif
			return true;
		}
			else
			{
				*pVoid5=0x01;
			}
		}

	}
	return false;
}
#if _MSC_VER>=1600
#ifdef _WIN64
bool RemoveEduPlotStamp_13(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000008;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x00000ba8;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#else
bool RemoveEduPlotStamp_13(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x00000884;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#endif
#elif _MSC_VER>=1500
#ifdef _WIN64
bool RemoveEduPlotStamp_10(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000008;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x00000b80;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#else
bool RemoveEduPlotStamp_10(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x0000086c;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#endif
#elif _MSC_VER>=1400
bool RemoveEduPlotStamp_09(const AcDbDatabase* pDb)
{
	return false;
}
//CAD08ȥ����������
bool RemoveEduPlotStamp_08(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x00000824;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
//CAD08ȥ����������
bool RemoveEduPlotStamp_07(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x000007dc;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#else
//CAD06ȥ����������
bool RemoveEduPlotStamp_06(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x000006d4;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
//CAD05ȥ����������
bool RemoveEduPlotStamp_05(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x000006d4;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
//CAD04ȥ����������
bool RemoveEduPlotStamp_04(const AcDbDatabase* pDb)
{
	DWORD d1=(DWORD)pDb;
	d1+=0x00000004;
	void** pVoid=(void**)d1;
	void* pVoid1=*pVoid;//ȡ���ڲ���mpImpDb��ַ
	DWORD d2=(DWORD)pVoid1;
	d2+=0x000006d4;//ȡ��mpImpDb�ڲ����Ƿ��ǽ�����ı�־
	void* pVoid2=(void*)d2;
	byte* pVoid3=(byte*)pVoid2;//ת��ΪDWORD,0x00000000:�ǽ�����,0x00000001:������
	if((*pVoid3)==0x01)
	{
		*pVoid3=0x00;
		return true;
	}
	else
	{
		return false;
	}
}
#endif

bool Split(CString& src, CString token, CStringArray& resultArray,bool ingoreEmptyString=false)
{
	if(src.IsEmpty())
	{
		return true;
	}
	int tokenSize = token.GetLength();
	CString result;
	CString srcouceStr = src;
	while (true)
	{
		int index = srcouceStr.Find(token);
		if (index == 0)
		{
			result = "";
		}
		else if (index < 0)
		{
			if((!ingoreEmptyString)||(!srcouceStr.IsEmpty()))
			{
				resultArray.Add(srcouceStr);
			}
			return true;
		}
		else
		{
			result = srcouceStr.Left(index);
		}
		if((!ingoreEmptyString)||(!result.IsEmpty()))
		{
			resultArray.Add(result);
		}

		int sourceLength = srcouceStr.GetLength();
		srcouceStr = srcouceStr.Right(sourceLength - index - tokenSize);
	}
}
//����:	ָ�����ַ����Ƿ��Ǻ���ĳ�������ֻ�ܴ���ʮ���Ƶģ�
//����:	value,ָ�����ַ���
//      nValue,���س������ͽ��
//����: �Ƿ��Ǻ���ĳ�����
BOOL IsValidLong(const CString value,long &lValue)
{
	bool bNegative=false;//�Ƿ��Ǹ���
	CString tmpValue=value;
	try
	{
		tmpValue.Trim();
	}
	catch(...)
	{

	}
	int nLen=tmpValue.GetLength();
	if(nLen==0)
		return FALSE;
	TCHAR c=tmpValue.GetAt(0);
	if(c=='-')
	{
		//����
		bNegative=true;
		if(nLen==1)
		{
			//ֻ��һ�������ǲ������
			return FALSE;
		}
		tmpValue=tmpValue.Right(nLen-1);
		nLen--;
	}
	long lTmpValue=0L;
	c=tmpValue.GetAt(0);
	if(c=='0')
	{
		if(nLen==1)
		{
			lValue=0L;
			return TRUE;
		}
		else
		{
			//��һλ��0���Һ��滹������������Ϊ�ǲ������
			return FALSE;
		}
	}
	else if(c>='1'&&c<='9')
	{
		lTmpValue+=lTmpValue*10+c-'0';
		for(int i=1;i<nLen;i++)
		{
			c=tmpValue.GetAt(i);
			if(c>='0'&&c<='9')
			{
				lTmpValue=lTmpValue*10+(c-'0');
			}
			else
			{
				//�����˷�������Ϊ�ǲ������
				return FALSE;
			}
		}
	}
	else
	{
		//�����˷�������Ϊ�ǲ������
		return FALSE;
	}
	lValue=bNegative?-lTmpValue:lTmpValue;
	return TRUE;
}
int _getHostAppMinorVersion()
{
#if _MSC_VER>=1400
	return acdbHostAppMinorVersion();
#else
	const TCHAR* lpRootKey=acrxProductKey();
	HKEY key = HKEY_LOCAL_MACHINE;
	DWORD acadNum = 0;
	if (RegOpenKeyEx(key, lpRootKey,0,KEY_READ, &key) != ERROR_SUCCESS)
	{
		return -1;
	}
	TCHAR strValue[128+1]={0};
	DWORD dwType;
	DWORD dwCount = sizeof(TCHAR)*128;
	LONG lResult = RegQueryValueEx(key, _T("Release"), NULL, &dwType,
		(LPBYTE)strValue, &dwCount);
	RegCloseKey(key);
	if(lResult != ERROR_SUCCESS)
	{
		return -1;
	}
	CString src(strValue);
	CString token=_T(".");
	CStringArray resultArray;
	Split(src,token,resultArray,true);
	if(resultArray.GetCount()<2)
	{
		return -1;
	}
	CString strMinorVersion=resultArray.GetAt(1);
	long nValue=-1;
	if(!IsValidLong(strMinorVersion,nValue))
	{
		return -1;
	}
	if(nValue<0)
	{
		return -1;
	}
	return nValue;
#endif
}
int Glb_AppMinorVersion=-9999;
int getHostAppMinorVersion()
{
	if(Glb_AppMinorVersion==-9999)
	{
		Glb_AppMinorVersion=_getHostAppMinorVersion();
	}
	return Glb_AppMinorVersion;
}
void RemoveEduPlotStamp(const AcDbDatabase* pDb)
{
	if(pDb==NULL)
	{
		return;
	}
	if(!pDb->isEMR())
	{
		return;
	}
	int nMinorVersion=getHostAppMinorVersion();
	bool rc=false;
#if _MSC_VER>=1600
	if(nMinorVersion==0)
	{
		rc=RemoveEduPlotStamp_13(pDb);
	}
#elif _MSC_VER>=1500
	if(nMinorVersion==0)
	{
		rc=RemoveEduPlotStamp_10(pDb);
	}
#elif _MSC_VER>=1400
	if(nMinorVersion==0)
	{
	rc=RemoveEduPlotStamp_07(pDb);
	}
	else if(nMinorVersion==1)
	{
	rc=RemoveEduPlotStamp_08(pDb);
	}
	else if(nMinorVersion==2)
	{
	rc=RemoveEduPlotStamp_09(pDb);
	}
#else
	if(nMinorVersion==0)
	{
	rc=RemoveEduPlotStamp_04(pDb);
	}
	else if(nMinorVersion==1)
	{
	rc=RemoveEduPlotStamp_05(pDb);
	}
	else if(nMinorVersion==2)
	{
	rc=RemoveEduPlotStamp_06(pDb);
	}
#endif
	if(rc)
	{
		rc=!pDb->isEMR();
	}
	if(rc)
	{
		acutPrintf(_T("\r\n����������־�ɹ�"));
	}
	else
	{
		acutPrintf(_T("\r\n����������־ʧ�ܣ�����ǿ�����"));
		rc=RemoveEduPlotStamp_Force(pDb);
		if(!rc)
		{
			acutPrintf(_T("\r\n����������־ʧ�ܣ��뽫����CAD�汾������ϵͳ�汾,32λϵͳ/64λϵͳ,32λCAD/64λCAD���͸�����\r\n����:wdzhangsl@126.com,QQ:245804736"));
		}
		else
		{
			acutPrintf(_T("\r\nǿ������������־�ɹ�"));
		}
		
	}
}