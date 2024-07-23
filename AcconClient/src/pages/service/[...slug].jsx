import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import {FaCaretRight} from "react-icons/fa";
import Link from "next/link";
import Head from "next/head";
import axios from "axios";
import https from 'https';

const Index = ({pageInformation,ogImage, siteUrl, structuredData , project, allProject}) => {
    return <div className="bg-white">
        <Head>
            <title>{pageInformation.metaTitle}</title>
            <meta name="description" content={pageInformation.metaDescription}/>
            <meta property="og:title" content={pageInformation.metaTitle}/>
            <meta property="og:description" content={pageInformation.metaDescription}/>
            <meta property="og:image" content={ogImage}/>
            <meta property="og:url" content={siteUrl}/>
            <meta name="twitter:card" content="summary_large_image"/>
            <meta name="twitter:title" content={pageInformation.metaTitle}/>
            <meta name="twitter:description" content={pageInformation.metaDescription}/>
            <meta name="twitter:image" content={ogImage}/>
            <script type="application/ld+json" dangerouslySetInnerHTML={{__html: JSON.stringify(structuredData)}}/>
        </Head>
        <div className="banner-slider" style={{
            backgroundImage: "url(/banner_service.jpg)",
        }}>
            <div className="bg"></div>
            <div className="banner-text">
                <h1>{pageInformation.header}</h1>
            </div>
        </div>
        <div className="single-service-area">
            <div className="container">
                <div className="row">
                    <div className="col-md-9">
                        <LazyLoadImage
                            src={`/${pageInformation.photo}`}
                            alt={`${pageInformation.photo}`}
                            className="service-main-photo"
                        />
                        <div className="single-service-text"
                             dangerouslySetInnerHTML={{__html: pageInformation.content}}></div>
                    </div>
                    <div className="col-md-3">
                        <div className="sidebar">
                            <div className="sidebar-item">
                                <h3>Projects</h3>
                                <ul>
                                    {pageInformation.lastServices?.map((item, index) => (
                                        <li key={index}>
                                            <FaCaretRight/>
                                            <Link href={`/service/${item.url}`}>{item.title}</Link>
                                        </li>))}
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
};

export default Index;


export const getServerSideProps = async (context) => {
    const {params, req} = context;
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const siteUrl = `${protocol}://${host}/service?slug=${params.slug[0]}`;

    const ogImage = `${protocol}://${host}/banner_service.jpg`;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getServicePage = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetServiceContentPage?Id=${params.slug[0]}`);

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
                    ogImage,
                    siteUrl,
                    structuredData,
                    pageInformation: servicePage
                }
            }
        }

    } catch
        (e) {
        return {
            redirect: {
                destination: '/404',
                permanent: false
            }
        }


        // if (project) {
        //     const allProject = cardJson.map(item => ({
        //         url: item.url, title: item.title
        //     }));
        //     return {
        //         props: {
        //             project: project || null,
        //             allProject: allProject
        //         }
        //     }
        // }
        //
        // return {
        //     redirect: {
        //         destination: '/service',
        //     },
        // }
    }
}
