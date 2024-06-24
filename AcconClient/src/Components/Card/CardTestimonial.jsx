import React from 'react';
import {FaQuoteLeft} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";

const CardTestimonial = ({data}) => {
    return <>
        <div className="testimonial-item">
            <div className="testimonial-text">
                <div className="client-name">
                    <h4>{data.name}</h4>
                    <span>{data.position}</span>
                </div>
                <div className="testimonial-detail">
                    <FaQuoteLeft/>
                    <p>
                        {data.description}
                    </p>
                </div>
                <div className="testimonial-photo">
                    <LazyLoadImage
                        src={data.url}
                        alt={data.url}
                    />
                </div>
            </div>
        </div>
    </>
};

export default CardTestimonial;
