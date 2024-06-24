import React from 'react';
import { cardJson } from "@/data/service";
import Card from "@/Components/Card/Card";
import Head from 'next/head';

const Service = ({ cardInfo, siteTitle, siteDescription, ogImage, siteUrl, structuredData }) => {
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
                    <h1>Service</h1>
                </div>
            </div>
            <section className="services-section">
                <div className="container services">
                    <div className="row">
                        {cardInfo.map((item, index) =>
                            <div key={index} className="col-md-4 col-sm-6 col-xs-12 clear-three">
                                <Card data={item} baseUrl={"service"} />
                            </div>
                        )}
                    </div>
                </div>
            </section>
        </>
    );
};

export default Service;

export const getServerSideProps = async ({ req }) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/service`;
    const siteTitle = "Services - Accon";
    const siteDescription = "Explore the range of services offered by Accon.";
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
                "url": `${protocol}://${host}/logo.png`
            }
        }
    };

    return {
        props: {
            cardInfo: cardJson,
            siteTitle,
            siteDescription,
            ogImage,
            siteUrl,
            structuredData
        }
    };
};
