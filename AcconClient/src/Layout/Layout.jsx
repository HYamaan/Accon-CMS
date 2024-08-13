import React, { useEffect, useState, useMemo } from 'react';
import Header from "@/Components/Layout/Header/Header";
import Footer from "@/Components/Layout/Footer/Footer";
import axios from "axios";

const Layout = ({ children }) => {
    const [layout, setLayout] = useState({});

    useEffect(() => {
        const getLayoutInformation = async () => {
            try {
                const getLayout = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetLayout`);
                if (getLayout.data.succeeded === false) {
                    console.log('Layout information not found');
                } else {
                    setLayout(getLayout.data.data);
                    console.log('Layout information:', getLayout.data.data);
                }
            } catch (error) {
                console.log('Error fetching layout information:', error);
            }
        };
        getLayoutInformation();
    }, []);

    const memoizedLayout = useMemo(() => layout, [layout]);

    return (
        <>
            <Header data={memoizedLayout.header} />
            {children}
            <Footer data={memoizedLayout.footer} />
        </>
    );
};

export default React.memo(Layout);
