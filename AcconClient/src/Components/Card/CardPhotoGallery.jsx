import React, { useState, useEffect } from 'react';
import { LazyLoadImage } from "react-lazy-load-image-component";
import { FaSearchPlus } from "react-icons/fa";
import { useMediaQuery } from 'react-responsive';
import Lightbox from "yet-another-react-lightbox";
import Download from "yet-another-react-lightbox/plugins/download";
import Fullscreen from "yet-another-react-lightbox/plugins/fullscreen";
import Captions from "yet-another-react-lightbox/plugins/captions";

const CardPhotoGallery = ({data}) => {
    const [open, setOpen] = useState(false);
    const [isMounted, setIsMounted] = useState(false);

    useEffect(() => {
        setIsMounted(true);
    }, []);

    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const handleCaptionClick = () => {
        if (isMobile) {
            setOpen(true);
        }
    };

    if (!isMounted) {
        return null;
    }

    return (
        <>
            <Lightbox
                open={open}
                close={() => setOpen(false)}
                slides={[{ src: data.url,  title: data.url.split('.')[0], downloadUrl: data.url, }]}
                plugins={[Download, Fullscreen,Captions]}
            />
            <div className="col-lg-3 col-md-4 col-sm-6 col-xs-12 ">
                <div className="caption-item" onClick={handleCaptionClick}>
                    <div className="caption-photo">
                        <LazyLoadImage
                            alt={data.url}
                            src={data.url}
                            effect="blur"
                        />
                        {!isMobile && (
                            <div className="caption-box">
                                <div className="caption-bg"></div>
                                <div className="caption-icon" onClick={() => setOpen(true)}>
                                    <FaSearchPlus />
                                </div>
                            </div>
                        )}
                    </div>
                    <div className="caption-text">
                        <p>{data.name}</p>
                    </div>
                </div>
            </div>
        </>
    );
};

export default CardPhotoGallery;
