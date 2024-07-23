import React from 'react';
import { cardJson } from "@/data/service";
import Card from "@/Components/Card/Card";
import Head from 'next/head';
import axios from "axios";
import https from 'https';
const Service = ({ servicePage,cardInfo, siteTitle, siteDescription, ogImage, siteUrl, structuredData }) => {
    console.log("servicePage",servicePage)
    return (
        <>
            <Head>
                <title>{servicePage.metaTitle}</title>
                <meta name="description" content={servicePage.metaDescription} />
                <meta property="og:title" content={servicePage.metaTitle} />
                <meta property="og:description" content={servicePage.metaDescription} />
                <meta property="og:image" content={ogImage} />
                <meta property="og:url" content={siteUrl} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={servicePage.metaTitle} />
                <meta name="twitter:description" content={servicePage.metaDescription} />
                <meta name="twitter:image" content={ogImage} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>{servicePage.header}</h1>
                </div>
            </div>
            <section className="services-section">
                <div className="container services">
                    <div className="row">
                        {servicePage.services?.map((item, index) =>
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


    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getServicePage = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetServicePage`);
        if (getServicePage.data.succeeded === false) {
            return {
                redirect: {
                    destination: '/404',
                    permanent: false
                }
            }
        } else {
            const servicePage = getServicePage.data.data;
            const structuredData = {
                "@context": "https://schema.org",
                "@type": "WebSite",
                "url": siteUrl,
                "name": servicePage.metaTitle,
                "description": servicePage.metaDescription,
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
                    servicePage,
                    cardInfo: cardJson,
                    siteTitle,
                    siteDescription,
                    ogImage,
                    siteUrl,
                    structuredData
                }
            };
        }
    }catch (e){
        return {
            redirect: {
                destination: '/404',
                permanent: false
            }
        }
    }


};
