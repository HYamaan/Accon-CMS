import React from 'react';
import Head from 'next/head';
import axios from "axios";
import https from "https";
const Index = ({ pageInformation, ogImage, siteUrl, structuredData }) => {
    return (
        <>
            <Head>
                <title>{pageInformation.metaTitle}</title>
                <meta name="description" content={pageInformation.metaDescription} />
                <meta property="og:title" content={pageInformation.metaTitle} />
                <meta property="og:description" content={pageInformation.metaDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={pageInformation.metaTitle} />
                <meta name="twitter:description" content={pageInformation.metaDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>{pageInformation.header}</h1>
                </div>
            </div>
            <div className="bg-white">
                <div className="container privacy-policy">
                    <div className="row">
                        <div className="col-12" dangerouslySetInnerHTML={{__html:pageInformation.content}}>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Index;

export const getServerSideProps = async ({ req }) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/terms`;
    const ogImage = `${protocol}://${host}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;


    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getTerms = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetTermsPage`);
        console.log("getTerms", getTerms.data);
        if (getTerms.data.succeeded === false) {
            return {
                redirect: {
                    destination: '/404',
                    permanent: false
                }
            };
        } else {
            const getTermsPage = getTerms.data.data;
            console.log("getTermsPage", getTermsPage)
            const structuredData = {
                "@context": "https://schema.org",
                "@type": "WebPage",
                "url": siteUrl,
                "name": getTermsPage.metaTitle || '',
                "description": getTermsPage.metaDescription || '',
                "publisher": {
                    "@type": "Organization",
                    "name": companyName,
                    "url": siteUrl,
                    "logo": {
                        "@type": "ImageObject",
                        "url": `${protocol}://${host}/logo.png`
                    }
                }
            };

            return {
                props: {
                    ogImage,
                    siteUrl,
                    structuredData,
                    pageInformation: getTermsPage,
                }
            };
        }
    }catch (e){
        return {
            redirect: {
                destination: '/404',
                permanent: false
            }
        };
    }


};
