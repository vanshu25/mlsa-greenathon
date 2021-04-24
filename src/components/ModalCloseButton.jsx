import './ModalCloseButton.scss';

import Close from '../assets/icons/close.svg';

const ModalCloseButton = (props = { onModalClose: () => { } }) => {
  return (
    <a className="close-btn" onClick={props.onModalClose}>
      <img alt="Close" src={Close} />
    </a>
  )
}

export default ModalCloseButton;