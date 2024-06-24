import React from 'react';
import { portFolioDetails, portFolioJson } from "@/data/portFolioJson";
import { FaCaretRight, FaQuoteLeft, FaQuoteRight } from "react-icons/fa";
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Carousel } from 'react-responsive-carousel';
import { LazyLoadImage } from "react-lazy-load-image-component";
import Link from "next/link";
import Head from 'next/head';
import { convert } from 'html-to-text';

const Index = ({ project, allProject, companyName, companyUrl }) => {
    const stripHtmlTags = (html) => {
        return convert(html, {
            wordwrap: 130
        });
    };

    const structuredData = {
        "@context": "https://schema.org",
        "@type": "CreativeWork",
        "name": project.title,
        "image": project.details.photos,
        "description": stripHtmlTags(project.details.longDescription),
        "provider": {
            "@type": "Organization",
            "name": companyName,
            "url": companyUrl
        },
        "author": {
            "@type": "Person",
            "name": project.details.clientName
        },
        "startDate": project.details.projectStartDate,
        "endDate": project.details.projectEndDate,
        "url": `${companyUrl}/portfolio/${project.url}`
    };

    return (
        <div className="bg-white">
            <Head>
                <title>{project.title}</title>
                <meta name="description" content={stripHtmlTags(project.details.longDescription)} />
                <meta property="og:title" content={project.title} />
                <meta property="og:description" content={stripHtmlTags(project.details.longDescription)} />
                <meta property="og:image" content={project.details.photos[0]} />
                <meta property="og:url" content={`${companyUrl}/portfolio/${project.url}`} />
                <meta name="twitter:card" content="summary_large_image" />
                <meta name="twitter:title" content={project.title} />
                <meta name="twitter:description" content={stripHtmlTags(project.details.longDescription)} />
                <meta name="twitter:image" content={project.details.photos[0]} />
                <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
            </Head>
            <div className="banner-slider" style={{ backgroundImage: "url(/banner_service.jpg)" }}>
                <div className="bg"></div>
                <div className="banner-text">
                    <h1>{project.title}</h1>
                </div>
            </div>
            <div className="single-service-area">
                <div className="container">
                    <div className="row">
                        <div className="col-md-9">
                            <Carousel showArrows={false} className="portfolio-carousel">
                                {project.details.photos.map((photo, index) => (<div key={index}>
                                    <LazyLoadImage
                                        src={`${photo}`}
                                        alt={`${photo}`}
                                    />
                                </div>))}
                            </Carousel>
                            <div className="single-service-text">
                                <h4>Description</h4>
                                <div dangerouslySetInnerHTML={{ __html: project.details.longDescription }}></div>
                                <div className="table-responsive">
                                    <table className="table table-bordered project-desc">
                                        <tbody>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Client Name
                                                </h4>
                                            </td>
                                            <td>{project.details.clientName}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Client Company
                                                </h4>
                                            </td>
                                            <td>{project.details.clientCompany}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Project Start Date
                                                </h4>
                                            </td>
                                            <td>{project.details.projectStartDate}</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Project End Date
                                                </h4>
                                            </td>
                                            <td>{project.details.projectEndDate}</td>
                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div className="single-service-text">
                                <h4>Client&#x2019;s Comment</h4>
                                {project.details.clientComment.map((comment, index) => (
                                    <div key={index} className="client-comment">
                                        <FaQuoteLeft />
                                        <p>{comment}</p>
                                        <FaQuoteRight className="quote-right" />
                                    </div>
                                ))}
                            </div>
                        </div>
                        <div className="col-md-3">
                            <div className="sidebar">
                                <div className="sidebar-item">
                                    <h3>Projects</h3>
                                    <ul>
                                        {allProject.map((item, index) => (
                                            <li key={index}>
                                                <FaCaretRight />
                                                <Link href={`/portfolio/${item.url}`}>{item.title}</Link>
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

export const getServerSideProps = async ({ params }) => {
    const project = portFolioDetails.find(item => item.url === params.slug[0]);
    const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;
    const companyUrl = process.env.NEXT_PUBLIC_COMPANY_URL;

    if (project) {
        const allProject = portFolioJson.map(item => ({
            url: item.url, title: item.title
        }));
        return {
            props: {
                project: project || null,
                allProject: allProject,
                companyName: companyName,
                companyUrl: companyUrl
            }
        }
    } else {
        return {
            redirect: {
                destination: '/portfolio',
            },
        }
    }
}
