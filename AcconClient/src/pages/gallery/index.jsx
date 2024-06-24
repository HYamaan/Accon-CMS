import React from 'react';
import Head from 'next/head';
import CardPhotoGallery from "@/Components/Card/CardPhotoGallery";
import { photoJson } from "@/data/photoJson";

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
                    <h1>Gallery</h1>
                </div>
            </div>
            <div className="photo-gallery-section pb-5 pt-5">
                <div className="container photo-gallery pb-3">
                    <div className="row">
                        {photoJson.map((photo, index) => {
                            return <CardPhotoGallery key={index} data={photo} />
                        })}
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
    const siteUrl = `${protocol}://${host}/gallery`;
    const siteTitle = "Gallery - Accon";
    const siteDescription = "Explore our photo gallery to see the projects and events we've been involved in.";
    const ogImage = `${protocol}://${host}/banner_service.jpg`;
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
            siteTitle,
            siteDescription,
            ogImage,
            siteUrl,
            structuredData
        }
    };
};
