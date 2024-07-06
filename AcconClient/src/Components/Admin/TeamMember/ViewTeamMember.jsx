import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewTeamMember = () => {
    const router = useRouter();
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const [teamMember, setTeamMember] = useState([]);
    const [tempTeamMember, setTempTeamMember] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Team/GetAllTeamMember`);
                if (response.data.succeeded) {
                    const responseData = response.data.data.teamMembers;
                    setTeamMember(responseData);
                    const filteredKeys = Object.keys(responseData[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching teamMember:', error);
            } finally {
                setLoading(false);
            }
            console.log('Sliders:', teamMember)
        };

        fetchSliders();
    }, []);

    const searchChangeHandler = (value) => {
        if (tempTeamMember.length === 0) {
            setTempTeamMember(teamMember);
        }

        if (value.length > 0) {
            const searchResults = teamMember.filter(member =>
                member.title.toLowerCase().includes(value.toLowerCase()) ||
                (member.designation && member.designation.toLowerCase().includes(value.toLowerCase()))
            );

            const exactMatches = searchResults.filter(member =>
                member.title.toLowerCase() === value.toLowerCase() ||
                (member.designation && member.designation.toLowerCase() === value.toLowerCase())
            );
            const otherMatches = searchResults.filter(member =>
                member.title.toLowerCase() !== value.toLowerCase() &&
                (!member.designation || member.designation.toLowerCase() !== value.toLowerCase())
            );

            setTeamMember([...exactMatches, ...otherMatches]);
        } else {
            setTeamMember(tempTeamMember);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/Team/DeleteTeamMember?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Team member deleted successfully")
                setTeamMember(teamMember.filter(teamMember => teamMember.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/team-member/edit/add?Id=${id}`);
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View Team Member</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/team-member/add")}
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
                                    <option value="Name">Name</option>
                                    <option value="Designation">Designation</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text"
                                   placeholder="Search"
                                      onChange={(e) => searchChangeHandler(e.target.value)}
                            />
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
                                        <span>Name</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Designation</span>
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
                            {
                                teamMember.map((member,index) =>(
                                    <Tr
                                        key={member.id}
                                    >
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${member.photo}`}
                                                alt={member.photo}
                                                className="slider-table-image"
                                            />
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {member.title}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {member.designation}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(member.id)}
                                                >Edit</button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(member.id)}
                                                >Delete</button>
                                            </div>
                                        </Td>
                                    </Tr>
                                ))
                            }
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

export default ViewTeamMember;
