
import React from 'react';
import dynamic from "next/dynamic";

const AdminHeader = dynamic(() =>
    import('@/Components/Layout/Header/AdminHeader'), {
    ssr: false
});

const AdminFooter = dynamic(() =>
    import('@/Components/Layout/Footer/AdminFooter'), {
    ssr: false
});

const AdminLayout = ({children}) => {
    return <>
        <AdminHeader/>
        {children}
        <AdminFooter/>
    </>
};

export default AdminLayout;
