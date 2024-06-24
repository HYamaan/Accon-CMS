import React from 'react';
import SliderRecentPost from "@/Components/Slider/SliderRecentPost";
import {recentPostJson} from "@/data/recentPostJson";
const RecentPost = () => {

    return <>
        <section className="recent-post-section">
            <div className="container recent-post">
                <div className="headline">
                    <h2>RECENT POSTS</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate</p>
                </div>
                <SliderRecentPost data={recentPostJson}/>
            </div>
        </section>
    </>
};

export default RecentPost;
