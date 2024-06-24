import React from 'react';
import {cardJson} from "@/data/service";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {FaCaretRight} from "react-icons/fa";
import Link from "next/link";
import Head from "next/head";

const Index = ({project, allProject}) => {
    return <div className="bg-white">
        <Head>
            <title>{project.title}</title>
            <meta name="description" content={project.description} />
            <meta property="og:title" content={project.title} />
            <meta property="og:description" content={project.description} />
            <meta property="og:image" content={project.photo} />
            <meta property="og:url" content={`https://www.example.com/service/${project.url}`} />
            <meta name="twitter:card" content="summary_large_image" />
            <meta name="twitter:title" content={project.title} />
            <meta name="twitter:description" content={project.description} />
            <meta name="twitter:image" content={project.photo} />
        </Head>
        <div className="banner-slider" style={{
            backgroundImage: "url(/banner_service.jpg)",
        }}>
            <div className="bg"></div>
            <div className="banner-text">
                <h1>{project.title}</h1>
            </div>
        </div>
        <div className="single-service-area">
            <div className="container">
                <div className="row">
                    <div className="col-md-9">
                        <LazyLoadImage
                            src={`${project.photo}`}
                            alt={`${project.photo}`}
                            className="service-main-photo"
                        />
                        <div className="single-service-text"
                             dangerouslySetInnerHTML={{__html: project.description}}></div>
                    </div>
                    <div className="col-md-3">
                        <div className="sidebar">
                        <div className="sidebar-item">
                                <h3>Projects</h3>
                                <ul>
                                    {allProject.map((item, index) => (
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


export const getServerSideProps = async ({params}) => {
    const project = cardJson.find(item => item.url === params.slug[0]);

    if (project) {
        const allProject = cardJson.map(item => ({
            url: item.url, title: item.title
        }));
        return {
            props: {
                project: project || null,
                allProject: allProject
            }
        }
    }

    return {
        redirect: {
            destination: '/service',
        },
    }
}
