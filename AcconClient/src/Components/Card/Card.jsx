import React, { useEffect, useState } from 'react';
import { LazyLoadImage } from "react-lazy-load-image-component";
import { useRouter } from "next/router";

const Card = ({ data, baseUrl }) => {
    const router = useRouter();
    const [htmlContent, setHtmlContent] = useState('');

    useEffect(() => {
        setHtmlContent(data.description);
    }, [data.description]);

    const handleRedirect = (url) => {
        router.push(`${baseUrl}/${url}`);
    };

    return (
        <div className="services-item">
            <LazyLoadImage
                alt={data.title}
                src={data.photo}
                className="services-photo"
            />
            <div className="services-text">
                <h3 onClick={() => handleRedirect(data.url)}>{data.title}</h3>
                <p dangerouslySetInnerHTML={{ __html: htmlContent }}></p>
                <div className="services-button">
                    <div onClick={() => handleRedirect(data.url)} className="secondary-button">
                        Read More
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Card;
