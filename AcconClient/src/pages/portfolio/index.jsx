import React from 'react';
import Head from 'next/head';
import PortFolioFilter from "@/Components/NotHeader/PortfolioFilter";

const Index = ({ siteTitle, siteDescription, ogImage, siteUrl, structuredData }) => {
    return (
        <>
            <Head>
                <title>{siteTitle}</title>
                <meta name="description" content={siteDescription} />
                <meta property="og:title" content={siteTitle} />
                <meta property="og:description" content={siteDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={siteTitle} />
                <meta name="twitter:description" content={siteDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>Portfolio</h1>
                </div>
            </div>
            <div className="bg-white py-2">
                <div className="container my-5">
                    <PortFolioFilter />
                </div>
            </div>
        </>
    );
};

export default Index;

export const getServerSideProps = async ({ req }) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/portfolio`;
    const siteTitle = "Portfolio - Accon";
    const siteDescription = "Explore our portfolio to see the projects we've worked on and the impact we've made.";
    const ogImage = `${siteUrl}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "WebSite",
        "url": siteUrl,
        "name": siteTitle,
        "description": siteDescription,
        "publisher": {
            "@type": "Organization",
            "name": companyName,
            "url": siteUrl,
            "logo": {
                "@type": "ImageObject",
                "url": `siteUrl`
            }
        }
    };

    return {
        props: {
            siteTitle,
            siteDescription,
            ogImage,
            siteUrl,
            structuredData
        }
    };
};
