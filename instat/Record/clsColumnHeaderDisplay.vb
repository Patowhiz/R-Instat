﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.
Public Class clsColumnHeaderDisplay
    Public Property strName As String

    Public ReadOnly Property strDisplayName As String
        Get
            Return strName & " " & strTypeShortCode
        End Get
    End Property

    Public Property strTypeShortCode As String

    Public Property clsColour As Color

    Public Property clsBackGroundColour As Color

    Public Property bIsFactor As Boolean

End Class
