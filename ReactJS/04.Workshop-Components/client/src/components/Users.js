import Search from './Search';
import Overlap from './overlap/Overlap';
import TableHead from './TableHead';
import UserRow from './UserRow';
import Pagination from './Pagination';

export default function Users({
    users,
    onInfoClick,
    onRemoveClick,
    onEditClick,
    onCreateClick,
}) {
    
    return (
        <section className="card users-container">

            <Search />

            <div className="table-wrapper">

                {/* Overlap components */}
                {/* <Overlap /> */}

                <table className="table">
                    <TableHead />
                    <tbody>
                        {users.map(user => <UserRow key={user._id}
                                                    {...user}
                                                    onInfoClick={onInfoClick}
                                                    onRemoveClick={onRemoveClick}
                                                    onEditClick={onEditClick}
                                            />)}
                    </tbody>
                </table>

            </div>

            <button className="btn-add btn" onClick={onCreateClick}>Add new user</button>

            <Pagination />

        </section>
    );
};