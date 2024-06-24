import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import Link from "next/link";
import {FaFacebookF, FaLinkedinIn, FaTwitter} from "react-icons/fa";
import {TfiYoutube} from "react-icons/tfi";

const CardTeam = ({data}) => {
    return <>
        <div className="team-item">
            <LazyLoadImage
                alt={data.url}
                src={data.url}
                className="team-photo"
            />
            <div className="team-text">
                <h4>{data.name}</h4>
                <p>{data.position}</p>
            </div>
            <ul className="team-social">
                <li>
                    <Link href={data.facebook}
                          target="_blank">
                        <FaFacebookF/>
                    </Link>
                </li>
                <li>
                    <Link href={data.twitter}
                          target="_blank">
                        <FaTwitter/>
                    </Link>
                </li>
                <li>
                    <Link href={data.linkedin} target="_blank">
                        <FaLinkedinIn/>
                    </Link>
                </li>
                <li>
                    <Link href={data.youtube}
                          target="_blank">
                        <TfiYoutube/>
                    </Link>
                </li>
            </ul>
        </div>
    </>
};

export default CardTeam;
