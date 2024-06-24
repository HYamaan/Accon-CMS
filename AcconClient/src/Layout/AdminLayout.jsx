import React from 'react';
import AdminHeader from "@/Components/Layout/Header/AdminHeader";
import AdminFooter from "@/Components/Layout/Footer/AdminFooter";

const AdminLayout = ({children}) => {
    return <>
        <AdminHeader/>
        {children}
        <AdminFooter/>
    </>
};

export default AdminLayout;
