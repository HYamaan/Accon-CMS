import React, {useEffect, useState} from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import {PiUserCircleFill} from "react-icons/pi";
import {useRouter} from "next/router";

const RecentPostCard = ({data}) => {
    const router = useRouter();
    const [htmlContent, setHtmlContent] = useState('');

    useEffect(() => {
        setHtmlContent(data.description);
    }, [data.description]);
    return<>
    <div className="blog-item">
     <LazyLoadImage
         src={data.photo}
         alt={data.photo}
     effect="blur"
     className="blog-photo"
     />
        <div className="blog-author">
            <div className="blog-gro">
                Posted On:{data.date}
            </div>
            <div className="blog-created">
                <PiUserCircleFill />
               <span> {data.created}</span>
            </div>
        </div>
        <div className="blog-text">
            <h3>Pri et oratio iisque atomorum, enim detracto</h3>
            <p dangerouslySetInnerHTML={{__html: htmlContent}}></p>
            <div className="blog-button">
                <div onClick={()=>router.push(`news/${data.url}`)} className="secondary-button">Read More</div>
            </div>
        </div>
    </div>
    </>
};

export default RecentPostCard;
