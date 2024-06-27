import React from 'react';
import {Table, Thead, Tbody, Tr, Th, Td} from 'react-super-responsive-table';
import 'react-super-responsive-table/dist/SuperResponsiveTableStyle.css';
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {useMediaQuery} from "react-responsive";
import {useRouter} from "next/router";
const ViewSlider = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Sliders</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/slider/add")}
                >
                    <FaPlus />
                    <span>Add New</span>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <div className="slider-show-content">
                        <div className="slider-show-content__counter">
                            <span>Showing entries</span>
                            <select name="slider-show-entries" id="slider-show-entries">
                                <option value="10">10</option>
                                <option value="20">20</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                        </div>
                        {
                            isMobile && <div className="slider-show-content__sort">
                                <span>Sort:</span>
                                <select name="slider-show-entries" id="slider-show-entries">
                                    <option value="SL">SL</option>
                                    <option value="Heading">Heading</option>
                                    <option value="Button1Text">Button1 Text</option>
                                    <option value="Button1Url">Button1 Url</option>
                                    <option value="Button2Text">Button2 Text</option>
                                    <option value="Button2Url">Button2 Url</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"/>
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                <div className="slider-table-head">
                                        <span>Photo</span>
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Heading</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Button1 Text</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Button1 URL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Button2 Text</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Button2 URL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            <Tr>
                                <Td>
                                    <div className="slider-table-body ">
                                        1
                                    </div>
                                </Td>
                                <Td>
                                    <LazyLoadImage
                                        src={"/slider-1.jpg"}
                                        alt={"slider-1.jpg"}
                                        effect="blur"
                                        className="slider-table-image"
                                    />
                                </Td>
                                <Td>
                                    <div className="slider-table-body ">
                                        HELPING BUILD A BETTER FUTURE
                                    </div>
                                </Td>
                                <Td>
                                    <div className="slider-table-body ">
                                        Read More
                                    </div>
                                </Td>

                                <Td>
                                    <div className="slider-table-body ">
                                        #
                                    </div>
                                </Td>
                                <Td>
                                    <div className="slider-table-body ">
                                        About Us
                                    </div>
                                </Td>
                                <Td>
                                    <div className="slider-table-body ">
                                        #
                                    </div>
                                </Td>
                                <Td>
                                    <div className="action-edit slider-table-body">
                                        <button className="btn btn-warning me-2">Edit</button>
                                        <button className="btn btn-danger">Delete</button>
                                    </div>
                                </Td>
                            </Tr>
                        </Tbody>
                    </Table>
                    <div className="pagination-section">
                        <div className="pagination-information">
                            <span>Showing </span>
                            <span>1</span>
                            <span>to</span>
                            <span>2</span>
                            <span>of</span>
                            <span>2</span>
                            <span>entries</span>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </>


};

export default ViewSlider;
