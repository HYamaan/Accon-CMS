import React from 'react';
import {LazyLoadImage} from "react-lazy-load-image-component";
import Link from "next/link";
import {FaFacebookF, FaLinkedinIn, FaTwitter} from "react-icons/fa";
import {TfiYoutube} from "react-icons/tfi";

const CardTeam = ({data}) => {
    return <>
        <div className="team-item">
            <LazyLoadImage
                alt={data.photo}
                src={`/${data.photo}`}
                className="team-photo"
            />
            <div className="team-text">
                <h4>{data.title}</h4>
                <p>{data.designation}</p>
            </div>
            <ul className="team-social">
                {data.facebook && <li>
                    <Link href={data.facebook}
                          target="_blank">
                        <FaFacebookF/>
                    </Link>
                </li>
                }
                {
                    data.twitter && <li>
                        <Link href={data.twitter}
                              target="_blank">
                            <FaTwitter/>
                        </Link>
                    </li>
                }
                {
                    data.linkedIn && <li>
                        <Link href={data.linkedIn}
                              target="_blank">
                            <FaLinkedinIn/>
                        </Link>
                    </li>
                }
                {
                    data.youtube && <li>
                        <Link href={data.youtube}
                              target="_blank">
                            <TfiYoutube/>
                        </Link>
                    </li>
                }
            </ul>
        </div>
    </>
};

export default CardTeam;
