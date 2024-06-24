import React from 'react';
import Header from "@/Components/Layout/Header/Header";
import Footer from "@/Components/Layout/Footer/Footer";

const Layout = ({children}) => {
    return <>
        <Header/>
        {children}
        <Footer/>

    </>
};

export default Layout;
