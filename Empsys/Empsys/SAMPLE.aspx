<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAMPLE.aspx.cs" Inherits="Empsys.SAMPLE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMplyoee Details</title>
</head>
<body>
    <form id="form1" runat="server">
   <h8 >Employee Data Management Using C# & SQL</h8>
    <div>
         <table>
           <tr>
               <td>EmployeeName:</td>
               <td> <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
               
           </tr>
           <tr>
               <td>DOB:</td>
               <td> <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox></td>
               
           </tr>
           <tr>
               <td>Location:</td>
               <td> <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></td>
               
           </tr>
           <tr>
               <td><asp:Button ID="btnSave" runat="server" Text="Save" Height="26px" OnClick="btnSave_Click" Width="59px" /></td>
               
           </tr>

       </table>
      </div>
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" Value="Insert" />
            <asp:HiddenField ID="HiddenField2" runat="server" Value="Select" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
            <asp:GridView ID="GridView1" runat="server" 
                DataKeyNames="EmpId" OnRowEditing="edit" 
        OnRowCancelingEdit="canceledit"
        OnRowDeleting="delete"
        OnRowUpdating="update"
        
         CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" /> 
        </asp:GridView>
            
      </div>
    </form>
</body>
</html>
