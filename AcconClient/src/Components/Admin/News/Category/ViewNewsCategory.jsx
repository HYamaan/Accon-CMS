import React from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";

const ViewNewsCategory = () => {
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View News Categories</h2>
                </div>
                <div className="view-border-header__add-view">
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
                                    <option value="FaqTitle">FAQ Title</option>
                                    <option value="ShowOnHome">Show On Home ?</option>
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
                                <Th className="w-25">
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>Category Name</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="w-25">
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
                                    <div className="slider-table-body ">
                                        Ex vix alienum sadipscing quod melius
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

export default ViewNewsCategory;
