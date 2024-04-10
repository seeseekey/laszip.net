﻿//===============================================================================
//
//  FILE:  laswriteitemraw_point10.cs
//
//  CONTENTS:
//
//    Implementation of LASwriteItemRaw for POINT10 items.
//
//  PROGRAMMERS:
//
//    martin.isenburg@rapidlasso.com  -  http://rapidlasso.com
//
//  COPYRIGHT:
//
//    (c) 2007-2017, martin isenburg, rapidlasso - tools to catch reality
//    (c) of the C# port 2014-2019 by Shinta <shintadono@googlemail.com>
//
//    This is free software; you can redistribute and/or modify it under the
//    terms of the GNU Lesser General Licence as published by the Free Software
//    Foundation. See the COPYING file for more information.
//
//    This software is distributed WITHOUT ANY WARRANTY and without even the
//    implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//  CHANGE HISTORY: omitted for easier Copy&Paste (pls see the original)
//
//===============================================================================

namespace LASzip.Net
{
	class LASwriteItemRaw_POINT10 : LASwriteItemRaw
	{
		public LASwriteItemRaw_POINT10() { }

		public unsafe override bool write(laszip_point item, ref uint context)
		{
			fixed (byte* pBuffer = buffer)
			{
				LASpoint10* p10 = (LASpoint10*)pBuffer;
				p10->X = item.X;
				p10->Y = item.Y;
				p10->Z = item.Z;
				p10->intensity = item.intensity;
				p10->flags = item.flags;
				p10->classification_and_classification_flags = item.classification_and_classification_flags;
				p10->scan_angle_rank = item.scan_angle_rank;
				p10->user_data = item.user_data;
				p10->point_source_ID = item.point_source_ID;
			}

			try
			{
				outstream.Write(buffer, 0, 20);
			}
			catch
			{
				return false;
			}

			return true;
		}

		readonly byte[] buffer = new byte[20];
	}
}
