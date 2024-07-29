import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import {FaCaretRight} from "react-icons/fa";
import Link from "next/link";
import {FaRegCalendarDays} from "react-icons/fa6";
import {PiUserCircleFill} from "react-icons/pi";
import {
    EmailIcon, EmailShareButton, FacebookIcon, FacebookShareButton,
    LinkedinIcon, LinkedinShareButton, PinterestIcon, PinterestShareButton,
    RedditIcon, RedditShareButton, TumblrIcon, TumblrShareButton,
    TwitterIcon, TwitterShareButton, WhatsappIcon, WhatsappShareButton
} from "react-share";
import Head from 'next/head';
import {convert} from 'html-to-text';
import axios from "axios";
import https from 'https';

const Index = ({project, ogImage, allProject, popularProject, latestProject, fullUrl, companyName, companyUrl}) => {
    const stripHtmlTags = (html) => {
        return convert(html, {
            wordwrap: 130
        });
    };

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "Article",
        "headline": project.title,
        "image": project.photo,
        "description": stripHtmlTags(project.description),
        "author": {
            "@type": "Person",
            "name": project.created
        },
        "publisher": {
            "@type": "Organization",
            "name": companyName,
            "url": companyUrl,
            "logo": {
                "@type": "ImageObject",
                "url": `${companyUrl}/logo.png`
            }
        },
        "datePublished": project.date,
        "url": fullUrl
    };

    return (
        <div className="bg-white">
            <Head>
                <title>{project.metaTitle}</title>
                <meta name="description" content={stripHtmlTags(project.metaDescription)}/>
                <meta property="og:title" content={project.metaTitle}/>
                <meta property="og:description" content={stripHtmlTags(project.metaDescription)}/>
                <meta property="og:image" content={ogImage}/>
                <meta property="og:url" content={fullUrl}/>
                <meta name="twitter:card" content="summary_large_image"/>
                <meta name="twitter:title" content={project.metaTitle}/>
                <meta name="twitter:description" content={stripHtmlTags(project.metaDescription)}/>
                <meta name="twitter:image" content={project.metaDescription}/>
                <script type="application/ld+json" dangerouslySetInnerHTML={{__html: JSON.stringify(structuredData)}}/>
            </Head>
            <div className="banner-slider" style={{backgroundImage: `url(/${project.backGroundPhoto})`}}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>{project.title}</h1>
                </div>
            </div>
            <div className="single-service-area">
                <div className="container">
                    <div className="row">
                        <div className="col-md-8">
                            <LazyLoadImage
                                src={`/${project.photo}`}
                                alt={`${project.photo}`}
                                className="service-main-photo"
                            />
                            <div className="single-blog-author">
                                <ul>
                                    <li className="gro">
                                        <FaRegCalendarDays/>
                                        <span>{project.date}</span>
                                    </li>
                                    <li className="blog-author-created">
                                        <PiUserCircleFill/>
                                        <span>{project.created}</span>
                                    </li>
                                </ul>
                            </div>
                            <div dangerouslySetInnerHTML={{__html: project.longDescription}}>
                            </div>
                            <h3>Share This</h3>
                            <div className="share-links">
                                <FacebookShareButton url={fullUrl}>
                                    <FacebookIcon size={32} round={true}/>
                                </FacebookShareButton>
                                <TwitterShareButton url={fullUrl}>
                                    <TwitterIcon size={32} round={true}/>
                                </TwitterShareButton>
                                <LinkedinShareButton url={fullUrl}>
                                    <LinkedinIcon size={32} round={true}/>
                                </LinkedinShareButton>
                                <PinterestShareButton url={fullUrl}>
                                    <PinterestIcon size={32} round={true}/>
                                </PinterestShareButton>
                                <RedditShareButton url={fullUrl}>
                                    <RedditIcon size={32} round={true}/>
                                </RedditShareButton>
                                <TumblrShareButton url={fullUrl}>
                                    <TumblrIcon size={32} round={true}/>
                                </TumblrShareButton>
                                <EmailShareButton url={fullUrl}>
                                    <EmailIcon size={32} round={true}/>
                                </EmailShareButton>
                                <WhatsappShareButton url={fullUrl}>
                                    <WhatsappIcon size={32} round={true}/>
                                </WhatsappShareButton>
                            </div>
                        </div>
                        <div className="col-md-4">
                            <div className="sidebar">
                                <div className="sidebar-item">
                                    <h3>News</h3>
                                    <ul>
                                        {project?.popularNews?.map((item, index) => (
                                            <li key={index}>
                                                <FaCaretRight/>
                                                <Link href={`/news/${item.url}`}>{item.title}</Link>
                                            </li>))}
                                    </ul>
                                    <h3 className="mt-3">Latest News</h3>
                                    <ul>
                                        {project?.latestNews?.map((item, index) => (
                                            <li key={index}>
                                                <FaCaretRight/>
                                                <Link href={`/news/${item.url}`}>{item.title}</Link>
                                            </li>))}
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Index;

export const getServerSideProps = async ({params, req}) => {
    const protocol = req.headers['x-forwarded-proto'] || 'http';
    const host = req.headers.host;
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;
    const siteUrl = `${protocol}://${host}/news?view=${params.slug[1]}`;
    const ogImage = `${protocol}://${host}/banner_service.jpg`;

    const axiosInstance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });

    try {
        const getNewsPage = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetNewsContentPage?Id=${params.slug[1]}`);

        if (getNewsPage.data.succeeded === false) {
            return {
                redirect: {
                    destination: '/404',
                    permanent: false
                }
            }
        } else {
            const newsPage = getNewsPage.data.data;
            const structuredData = {
                "@context": "https://schema.org",
                "@type": "WebSite",
                "url": siteUrl,
                "name": newsPage.metaTitle || "Default Title",
                "description": newsPage.metaDescription || "Default Description",
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
                    project: newsPage
                }
            }
        }

    } catch (e) {
        return {
            redirect: {
                destination: '/404',
                permanent: false
            }
        }
    }
}
