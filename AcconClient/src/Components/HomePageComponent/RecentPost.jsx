import React from 'react';
import SliderRecentPost from "@/Components/Slider/SliderRecentPost";
import {recentPostJson} from "@/data/recentPostJson";
const RecentPost = ({news}) => {

    return <>
        <section className="recent-post-section">
            <div className="container recent-post">
                <div className="headline">
                    <h2>{news.title}</h2>
                    <p>{news.subTitle}</p>
                </div>
                <SliderRecentPost data={news.news}/>
            </div>
        </section>
    </>
};

export default RecentPost;
