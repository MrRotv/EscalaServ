using EscalaServ.Application.ViewModels;
using EscalaServ.Core.Repositories;
using EscalaServ.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalaServ.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authservice;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authservice, IUserRepository userRepository)
        {
            _authservice = authservice;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authservice.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetUserByNipAndPassword(request.Nip, passwordHash);
            if (user == null) return null;

            var token = _authservice.GenerateJwtToken(user.Nip, user.Role);

            return new LoginUserViewModel(request.Nip, token);

        }
    }
}
